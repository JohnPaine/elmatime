using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ImpeltechTime.Droid.Core.Model;

namespace ImpeltechTime.Droid.Core.Internal
{
    public class ElmaUser : IElmaUser
    {
        private readonly IElmaWcfService _wcfService;

        public ElmaUser (long id, Guid uid, IElmaWcfService wcfService) {
            Id = id;
            TypeUid = "18faf3ae-03c9-4e64-b02a-95dd63e54c4d";
            Uid = uid;
            _wcfService = wcfService;
        }

        public long Id { get; }
        public string TypeUid { get; }
        public Guid Uid { get; set; }
        public void GetObjectData (SerializationInfo info, StreamingContext context) {
            throw new NotImplementedException ();
        }

        public string AccountName { get; set; }
        public string InitialPass { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}