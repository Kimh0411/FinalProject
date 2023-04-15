using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Network
{
    class Packet
    {
        //--[Client --> Server]
        private const string IDCONTAINCHECK = "IdContainCheck";    //@중복체크
        private const string NEWMEMBER = "NewMember";              //@회원가입
        private const string LOGIN = "Login";                      //@로그인
        private const string SELECTMEMBER = "SelectMember";        //@검색
        private const string UPDATEMEMBER = "UpdateMember";        //@수정
        private const string DELETEMEMBER = "Deletemember";        //@수정
        private const string LOGOUT = "Logout";        //@수정

        public static string IdContainCheck(string id)
        {
            string packet = string.Format("{0}@{1}", IDCONTAINCHECK, id);

            return packet;
        }
        public static string NewMember(string id, string pw, string name, string phone, int age)
        {
            string packet = string.Format("{0}@{1}#{2}#{3}#{4}#{5}", NEWMEMBER, id, pw, name, phone, age);

            return packet;
        }
        public static string Login(string id, string pw)
        {
            string packet = string.Format("{0}@{1}#{2}", LOGIN, id, pw);
            return packet;
        }



        public static string SelectMember(string id)
        {
            string packet = string.Format("{0}@{1}", SELECTMEMBER, id);

            return packet;
        }

        public static string UpdateMember(string id, string phone, int age)
        {
            string packet = string.Format("{0}@{1}#{2}#{3}", UPDATEMEMBER, id, phone, age);

            return packet;
        }
        public static string Deletemember(string id)
        {
            string packet = string.Format("{0}@{1}", DELETEMEMBER, id);

            return packet;
        }
        public static string Logout(string id)
        {
            string packet = string.Format("{0}@{1}", LOGOUT, id);

            return packet;
        }



    }
}
