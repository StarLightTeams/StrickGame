using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerConnect : MonoBehaviour {

    public int connectionToserver()
    {
        Connection connection = new Connection();
        return connection.conectionServer();
    }
}
