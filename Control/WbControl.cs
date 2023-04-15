using FinalProject.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Control
{
    internal class WbControl
    {
        #region 싱글톤
        private WbControl() { }
        public static WbControl Instance { get; private set; }
        static WbControl()
        {
            Instance = new WbControl();
        }
        #endregion

        #region 네트웤 사용 필드
        //private const string SERVER_IP = "127.0.0.1";
        private const string SERVER_IP = "34.22.70.19";
        private const int SERVER_PORT = 7000;

        private WbClient client = new WbClient();
        #endregion

        private MainWindow start = null;

        #region 서버연결
        public void Init(MainWindow start1)
        {
            start = start1;
            if (client.Start(SERVER_IP, SERVER_PORT, LogMessage, RecvMessage) == false)
                return;
        }
        #endregion

        public bool Idcontaincheck { get; private set; }
        public bool Newmember { get; private set; }
        public bool Updatemember { get; private set; }
        public bool Deletemember { get; private set; }
        public bool Logoutmember { get; private set; }


        #region 네트웤 콜백 메서드
        private void LogMessage(LogFlag flag, string msg)
        {
            Console.WriteLine("[{0}] : {1} ({2})", flag, msg, DateTime.Now.ToString());
        }

        private void RecvMessage(string msg)
        {
            string[] sp = msg.Split('@');
            switch (sp[0])
            {
                //case "IdContainCheck": IdContainCheck_Ack(sp[1]); break;
                //case "Login": Login_Ack(sp[1]); break;//...
                //case "NewMember": NewMember_Ack(sp[1]); break;
            }
        }
        #endregion

        #region 아이디 중복체크
        public void IdContainCheck(string id)
        {
            string packet = Packet.IdContainCheck(id);
            client.SendData(packet);
        }

        public void IdContainCheck_Ack(string msg)
        {
            Idcontaincheck = Convert.ToBoolean(msg);
        }

        #endregion

        #region 회원가입
        public void NewMember(string id, string pw, string name, string phone, int age)
        {
            //doc.NewMember(new Member(id, pw, name, phone, age));
            string packet = Packet.NewMember(id, pw, name, phone, age);
            client.SendData(packet);
        }

        //회원가입 완료 : TRUE
        public void NewMember_Ack(string msg)
        {
            Newmember = Convert.ToBoolean(msg);
        }
        #endregion
    }
}
