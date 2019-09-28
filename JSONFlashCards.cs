using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GraceOfGuru
{

    public class JSONFlashCards
    {
      //  public string Alphabet { get; set; }
        public string Location { get; set; }
    }

    public class ResRoot
    {
        public Dictionary<string, JSONFlashCards> Files { set; get; }
    }
}
