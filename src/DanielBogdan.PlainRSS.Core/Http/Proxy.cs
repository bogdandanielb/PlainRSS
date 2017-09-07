using System;
using System.Text.RegularExpressions;

namespace DanielBogdan.PlainRSS.Core.Http
{
    /// <summary>
    /// Proxy class
    /// </summary>
    [Serializable]
    public class Proxy
    {
        private const string IpPattern =
            @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

        private const string PortPattern =
            @"^(6553[0-5]|655[0-2]\d|65[0-4]\d\d|6[0-4]\d{3}|[1-5]\d{4}|[1-9]\d{0,3}|0)$";

        private string ip;
        private string port;
        private string username;
        private string password;

        /// <summary>
        /// Proxy IP
        /// </summary>
        public string Ip
        {
            get { return ip; }
            set
            {
                if (!Regex.IsMatch(value, IpPattern, RegexOptions.IgnoreCase))
                    throw new ArgumentException("Invalid pattern", nameof(Ip));

                ip = value;

            }
        }

        /// <summary>
        /// Proxy port
        /// </summary>
        public string Port
        {
            get { return port; }
            set
            {
                if (!Regex.IsMatch(value, PortPattern, RegexOptions.IgnoreCase))
                    throw new ArgumentException("Invalid pattern", nameof(Port));

                port = value;

            }
        }

        /// <summary>
        /// Proxy username when authentication is required
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        /// <summary>
        /// Proxy password when authentication is required
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// c-tor 1
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public Proxy(string ip, string port)
        {
            this.Ip = ip;
            this.Port = port;
        }

        /// <summary>
        /// c-tor 2
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Proxy(string ip, string port, string username, string password)
        {
            this.Ip = ip;
            this.Port = port;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Displays ip:port
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Ip + ":" + this.Port;
        }



        public override bool Equals(object obj)
        {
            if (obj != null && obj is Proxy)
            {

                var temp = obj as Proxy;
                if (temp.Ip == this.Ip && temp.Port == this.Port)
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Ip.GetHashCode() ^ this.Port.GetHashCode();
        }


        /// <summary>
        /// Verify if the IPs and Ports are in correct format
        /// Kept for backwards compatibility with static checkers
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static bool VerifyIpAndPort(string ip, string port)
        {

            if (string.IsNullOrEmpty(ip))
            {
                throw new ArgumentNullException(nameof(ip), "IP should not be empty");
            }

            if (string.IsNullOrEmpty(port))
            {
                throw new ArgumentNullException(nameof(port), "Port should not be empty");
            }

            if (!Regex.IsMatch(ip, IpPattern))
                return false;


            if (!Regex.IsMatch(port, PortPattern))
                return false;

            return true;
        }
    }
}
