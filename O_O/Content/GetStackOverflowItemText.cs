using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stacky;
namespace O_O.Content
{
    public class GetStackOverflowItemText
    {
        public static HtmlString GetText(UserEvent e) {
            string s = "I ";
            switch (e.Type)
            {
                case UserEventType.Comment: s += "<a href=\"http://stackoverflow.com/questions/" + e.PostId + "/#comment-" + e.CommentId + "\">commented</a> on a <a href=\"http://stackoverflow.com/questions/" + e.PostId + "\">question</a>"; break;
                case UserEventType.AskOrAnswered: s += "<a href=\"http://stackoverflow.com/questions/" + e.PostId + "\">"+ e.Action.Replace("ed","") + "ed</a> a question"; break;
                case UserEventType.Badge: s += "earned a badge"; break;
            }
            if (s == "I ") s = ""; else s += "\n";
            return new HtmlString(s);
        }
    }
}