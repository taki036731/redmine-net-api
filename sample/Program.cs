using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Redmine.Net.Api;
using Redmine.Net.Api.Async;
using Redmine.Net.Api.Extensions;
using Redmine.Net.Api.Net;
using Redmine.Net.Api.Types;


namespace sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new RedmineManagerOptionsBuilder();
            builder.WithApiKeyAuthentication("43ec21d2c57c6d5c90eb6b65f209fde1f36fa0cd")
                .WithHost("http://localhost:3000")
                .WithSerializationType(Redmine.Net.Api.Serialization.SerializationType.Xml);
            var manager = new RedmineManager(builder);

            var opts = new RequestOptions();
            opts.ImpersonateUser = "fugafuga";
            var fn = @"C:\Users\takizawa.osamu\Desktop\images.tar.gz";

            var upload = manager.UploadFile(System.IO.File.ReadAllBytes(fn));
        }

        static async Task _Main(string[] args)
        {
            var builder = new RedmineManagerOptionsBuilder();
            builder.WithApiKeyAuthentication("43ec21d2c57c6d5c90eb6b65f209fde1f36fa0cd")
                .WithHost("http://localhost:3000")
                .WithSerializationType(Redmine.Net.Api.Serialization.SerializationType.Xml);
            var manager = new RedmineManager(builder);

            var opts = new RequestOptions();
            opts.ImpersonateUser = "fugafuga";

            var user = await manager.GetCurrentUserAsync(opts);


            //var issue = new Issue();
            //issue.Project = IdentifiableName.Create<Project>(1);
            //issue.Subject = "Test";

            //var saved = await manager.CreateAsync<Issue>(issue, opts);

            var reqopts = new RequestOptions();
            reqopts.QueryString = new System.Collections.Specialized.NameValueCollection
            {
                {RedmineKeys.INCLUDE, RedmineKeys.ISSUE_CUSTOM_FIELDS  }
            };
            var tracker = await manager.GetAsync<Tracker>();
            var project = await manager.GetAsync<Project>("1", reqopts);
            //var role = await manager.GetAsync<Role>("4");

            var issue = new Issue();
            issue.Project = IdentifiableName.Create<IdentifiableName>(1);
            issue.Subject = "hogehoge";
            var saved = manager.Create(issue);


            Console.WriteLine(user.Login);
        }

    }
}
    