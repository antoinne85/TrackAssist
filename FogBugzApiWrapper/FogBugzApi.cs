using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using FogBugzApiWrapper.Contracts;
using FogBugzApiWrapper.Data;
using FogBugzApiWrapper.RequestObjects;
using FogBugzApiWrapper.Requests.Cases;

namespace FogBugzApiWrapper
{
    public interface IFogBugzApi
    {
        bool IsLoggedIn { get; }
        LoginResult Login(string username, string password);
        void Logout();
        List<Case> ListCases();
        T Execute<T>(GenericFogBugzRequest request) where T : class;
        string ExecuteSimple(GenericFogBugzRequest request);
        T Execute<T>(string uri) where T : class;
        string ExecuteSimple(string uri);
        List<User> ListUsers();
        List<Milestone> ListMilestones();
        List<Interval> ListIntervals();
        List<Interval> ListIntervals(int maxDaysAgo);
    }

    public class FogBugzApi : IFogBugzApi
    {
        private readonly string _apiEndpoint;
        private readonly GenericFogBugzRequestUriBuilder _uriBuilder;
        private string LoginToken { get; set; }

        public bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(LoginToken); }
        }

        public FogBugzApi(string apiEndpoint, GenericFogBugzRequestUriBuilder uriBuilder)
        {
            if (uriBuilder == null)
            {
                throw new ArgumentNullException("uriBuilder");
            }

            if (string.IsNullOrWhiteSpace(apiEndpoint))
            {
                throw new ArgumentException("The apiEndpoint parameter must not contain only whitespace.");
            }

            _apiEndpoint = apiEndpoint;
            _uriBuilder = uriBuilder;
        }

        public LoginResult Login(string username, string password)
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.Login,
                Arguments = new List<IGenericRequestArgument>
                {
                    new GenericRequestArgument
                    {
                        Argument = Argument.Email,
                        Value = username
                    },
                    new GenericRequestArgument
                    {
                        Argument = Argument.Password,
                        Value = password
                    }
                }
            };

            var result = Execute<LoginResult>(request);
            if (!string.IsNullOrWhiteSpace(result.LoginToken))
            {
                LoginToken = result.LoginToken;
            }
            //TODO: Support ambiguous logins.
            return result;
        }

        public void Logout()
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.Login,
                Arguments = new List<IGenericRequestArgument>
                {
                    new GenericRequestArgument
                    {
                        Argument = Argument.LoginToken,
                        Value = LoginToken
                    }
                }
            };
            ExecuteSimple(request);
            LoginToken = null;
        }

        private Stream GetResponseStream(string uri)
        {
            var request = HttpWebRequest.Create(uri);
            var response = request.GetResponse();
            return response.GetResponseStream();
        }

        public List<Case> ListCases()
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.Search,
                Arguments = new List<IGenericRequestArgument>
                {
                    new QueryRequestArgument
                    {
                        QueryFilters = new List<IQueryFilter>
                        {
                            new QueryFilter
                            {
                                Argument = QueryArgument.Status,
                                Value = "Active"
                            }
                        }
                    },
                    new CaseColumnArgument
                    {
                        BasicColumns = CaseColumn.AssignedToUserName | CaseColumn.MilestoneName | CaseColumn.Title | CaseColumn.CurrentEstimateInHours | CaseColumn.ElapsedHours
                    }
                }
            };

            var result = Execute<Response>(request);
            return result.Cases.ToList();
        }

        public List<User> ListUsers()
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.ListUsers
            };
            var result = Execute<Response>(request);
            return result.Users.ToList();
        }

        public List<Milestone> ListMilestones()
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.ListMilestones
            };
            var result = Execute<Response>(request);
            return result.Milestones.ToList();
        }

        public List<Interval> ListIntervals()
        {
            return ListIntervals(7);
        }

        public List<Interval> ListIntervals(int maxDaysAgo)
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.ListIntervals,
                Arguments = new List<IGenericRequestArgument>
                {
                    new GenericRequestArgument
                    {
                        Argument = Argument.StartDate,
                        Value = DateTime.UtcNow.AddDays(maxDaysAgo).ToString("u")
                    },
                    new GenericRequestArgument
                    {
                        Argument = Argument.EndDate,
                        Value = DateTime.UtcNow.ToString("u")
                    },
                    new GenericRequestArgument
                    {
                        Argument = Argument.UserId,
                        Value = "1"
                    }
                }
            };
            var simple = ExecuteSimple(request);
            var result = Execute<Response>(request);
            return result.Intervals.ToList();
        }

        public Case GetDetails(int caseNumber)
        {
            var request = new GenericFogBugzRequest
            {
                Command = Command.Search,
                Arguments = new List<IGenericRequestArgument>
                {
                    new QueryRequestArgument
                    {
                        QueryFilters = new List<IQueryFilter>
                        {
                            new QueryFilter
                            {
                                Argument = QueryArgument.Status,
                                Value = "Active"
                            },
                            new QueryFilter
                            {
                                Argument = QueryArgument.CaseNumber,
                                Value = caseNumber.ToString()
                            }
                        }
                    },
                    new CaseColumnArgument
                    {
                        BasicColumns = CaseColumn.AssignedToUserName | CaseColumn.MilestoneName | CaseColumn.Title | CaseColumn.CurrentEstimateInHours | CaseColumn.ElapsedHours | CaseColumn.Events,
                    }
                }
            };

            var result = Execute<Response>(request);
            return result.Cases.FirstOrDefault();
        }

        public T Execute<T>(GenericFogBugzRequest request) where T : class
        {
            AddLoginToken(request);
            var uri = _uriBuilder.Generate(_apiEndpoint, request);
            return Execute<T>(uri);
        }

        public string ExecuteSimple(GenericFogBugzRequest request)
        {
            AddLoginToken(request);
            var uri = _uriBuilder.Generate(_apiEndpoint, request);
            return ExecuteSimple(uri);            
        }

        private void AddLoginToken(GenericFogBugzRequest request)
        {
            if (!request.HasArgument(Argument.LoginToken))
            {
                request.Arguments.Add(new GenericRequestArgument
                {
                    Argument = Argument.LoginToken,
                    Value = LoginToken
                });
            }
        }

        public T Execute<T>(string uri) where T : class
        {
            using (var stream = GetResponseStream(uri))
            {
                var serializer = new GenericSerializer();
                var result = serializer.Deserialize<T>(stream);
                return result;
            }
        }

        public string ExecuteSimple(string uri)
        {
            using(var stream = GetResponseStream(uri))
            using (var textReader = new StreamReader(stream))
            {
                return textReader.ReadToEnd();
            }
        }
    }
}
