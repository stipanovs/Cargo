using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoLogistic.Domain.Users
{
    class UserMessageBox
    {
        private string _from, _subject, _content;
        private bool _unread = true;

        public UserMessageBox(string from, string subject, string content)
        {
            _from = from;
            _subject = subject;
            _content = content;
        }

    }
}
