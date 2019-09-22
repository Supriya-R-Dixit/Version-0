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

using Microsoft.Graph;

namespace GraceOfGuru
{
    public class GraphHelper: IAuthenticationProvider
    {
    private static GraphHelper INSTANCE = null;
    private IGraphServiceClient mClient = null;
    private String mAccessToken = null;
}
}