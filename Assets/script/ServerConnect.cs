using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnect : MonoBehaviour {

    public void connectionToserver()
    {
        Connection connection = new Connection();
        connection.conectionServer();
    }
}
