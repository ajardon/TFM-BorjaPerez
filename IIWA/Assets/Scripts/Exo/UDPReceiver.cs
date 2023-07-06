using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceiver : MonoBehaviour
{
    public int Port;
    private UdpClient _ReceiveClient;
    private Thread _ReceiveThread;
    private IReceiverObserver _Observer;

    private int move;
    private bool move0, move1, move2, move3, move4;

    void Start()
    {
        Initialize();
        move = 0;
        PlayerPrefs.SetInt("Movement", move);
    }

    private void Update()
    {
        //REPOSO
        if (move0 == true)
        {
            move = 0;
            PlayerPrefs.SetInt("Movement", move);
        }

        //ARRIBA
        if (move1 == true)
        {
            move = 1;
            PlayerPrefs.SetInt("Movement", move);
        }

        //ABAJO
        if (move2 == true)
        {
            move = 2;
            PlayerPrefs.SetInt("Movement", move);
        }
        //IZQUIERDA
        if (move3 == true)
        {
            move = 3;
            PlayerPrefs.SetInt("Movement", move);
        }
        //DERECHA
        if (move4 == true)
        {
            move = 4;
            PlayerPrefs.SetInt("Movement", move);
        }
    }

    /// <summary>
    /// Initialize objects.
    /// </summary>
    public void Initialize()
    {
        // Receive
        _ReceiveThread = new Thread(
            new ThreadStart(ReceiveData));
        _ReceiveThread.IsBackground = true;
        _ReceiveThread.Start();
    }

    public void SetObserver(IReceiverObserver observer)
    {
        _Observer = observer;
    }

    /// <summary>
    /// Receive data with pooling.
    /// </summary>
    private void ReceiveData()
    {
        _ReceiveClient = new UdpClient(Port);

        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = _ReceiveClient.Receive(ref anyIP);

                double[] values = new double[data.Length / 8];
                Buffer.BlockCopy(data, 0, values, 0, values.Length * 8);

                if (_Observer != null)
                    _Observer.OnDataReceived(values);


                //REPOSO
                if (values[0] == 1)
                {
                    move0 = true;
                    move1 = false;
                    move2 = false;
                    move3 = false;
                    move4 = false;
                }
                //ARRIBA
                if(values[1] == 1)
                {
                    move1 = true;
                    move0 = false;
                    move2 = false;
                    move3 = false;
                    move4 = false;
                }
                //ABAJO
                if (values[2] == 1)
                {
                    move1 = false;
                    move0 = false;
                    move2 = true;
                    move3 = false;
                    move4 = false;
                }
                //IZQUIERDA
                if (values[3] == 1)
                {
                    move1 = false;
                    move0 = false;
                    move2 = false;
                    move3 = true;
                    move4 = false;
                }
                //DERECHA
                if (values[4] == 1)
                {
                    move1 = false;
                    move0 = false;
                    move2 = false;
                    move3 = false;
                    move4 = true;
                }

            }
            catch (Exception err)
            {
                Debug.Log("<color=red>" + err.Message + "</color>");
            }
        }
    }

    /// <summary>
    /// Deinitialize everything on quiting the application.Or you might get error in restart.
    /// </summary>
    private void OnApplicationQuit()
    {
        try
        {
            _ReceiveThread.Abort();
            _ReceiveThread = null;
            _ReceiveClient.Close();
        }
        catch (Exception err)
        {
            Debug.Log("<color=red>" + err.Message + "</color>");
        }
    }
}
