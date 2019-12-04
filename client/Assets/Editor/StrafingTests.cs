using System.Collections;
using System.Collections.Generic;
using Movement;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class StrafingTests
    {
        [Test]
        public void StrafingTestsSimplePasses()
        {
            var str = new Strafing();
            var go = new GameObject();
            go.transform.forward = Vector3.right;
            go.transform.right = Vector3.down;

            Assert.AreEqual(1, str.Get(new Vector3(0, 0, 1), go.transform));
        }
    }
}
