using System.Collections.Generic;
using UnityEngine;

using ClownFiesta.Core;

namespace ClownFiesta.Networking {

    public class NetworkEntity : Entity {
        public string Id { get; set; }
        public AuthorityType AuthorityType { get; set; }
    }

    public enum AuthorityType {
        Local,
        Remote,
    }
}
