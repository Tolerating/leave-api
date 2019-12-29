using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace leaveAPI.Models
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string name, int id)
        {
            Name = name;
            ID = id;
        }
        public string Name { get; }
        public int ID { get; set; }
        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }
    }

    public class ApplicationUser : IPrincipal
    {
        public ApplicationUser(string name, int id)
        {
            Identity = new UserIdentity(name, id);
        }
        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}