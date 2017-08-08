using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace System.Net.Sockets
{
    public class Connector
    {
        public static bool SerialPortTest(string comPort, ref string msg)
        {
            if (string.IsNullOrEmpty(comPort))
            {
                msg = "Unknown COMPORT Information.";
                return false;
            }

            SerialPort s = new SerialPort(comPort);
            try
            {
                s.Open();

                msg = DateTime.Now.ToString()
                    + Environment.NewLine + "SerialPortTest"
                    + Environment.NewLine + comPort
                    + Environment.NewLine + "Success";

            }
            catch (Exception ex)
            {
                msg = DateTime.Now.ToString()
                    + Environment.NewLine + "SerialPortTest"
                    + Environment.NewLine + comPort
                    + Environment.NewLine + "Error"
                    + Environment.NewLine + ex.ToString();

                return false;
            }
            finally
            {
                try
                {
                    s.Close();
                }
                catch 
                {
                }
            }


            return true;
        }

        public static bool Ping(string host, ref string msg)
        {
            if (string.IsNullOrEmpty(host))
            {
                msg = "Unknown PING Information.";
                return false;
            }

            Ping p = new Ping();
            PingReply r;
            r = p.Send(host);

            if (r.Status != IPStatus.Success)
            {
                msg = DateTime.Now.ToString()
                                + Environment.NewLine + "Ping : " + host.ToString()
                                + Environment.NewLine + "[" + host.ToString() + "] " + r.Status.ToString()
                                + Environment.NewLine + "[Response Time] " + r.RoundtripTime.ToString() + " ms";
            }
            else
            {
                msg = DateTime.Now.ToString()
                        + Environment.NewLine + "Ping : " + host.ToString()
                        + Environment.NewLine + "[" + r.Address.ToStringAbs() + "] " + r.Status.ToString()
                        + Environment.NewLine + "[Response Time] " + r.RoundtripTime.ToString() + " ms";
            }

            return (r.Status == IPStatus.Success);
        }

        public static bool Telnet(string host, int port, ref string msg)
        {
            if (string.IsNullOrEmpty(host))
            {
                msg = "Unknown PING Information.";
                return false;
            }

            try
            {
                using (TcpClient t = new TcpClient(host, port))
                {
                    msg = DateTime.Now.ToString()
                        + Environment.NewLine + "Telnet"
                        + Environment.NewLine + host + ":" + port.ToString()
                        + Environment.NewLine + "Success";
                }

            }
            catch (Exception ex)
            {
                msg = DateTime.Now.ToString()
                    + Environment.NewLine + "Telnet"
                    + Environment.NewLine + host + ":" + port.ToString()
                    + Environment.NewLine + "Error"
                    + Environment.NewLine + ex.ToString();

                return false;
            }

            return true;
        }
    }
}
