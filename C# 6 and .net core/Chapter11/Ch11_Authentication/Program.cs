using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Security.Permissions;
using System.Security.Principal;

namespace Ch11_Authentication
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            WriteLine($"Name:{user.Identity.Name}");
            WriteLine($"是否验证：{user.Identity.IsAuthenticated}");
            WriteLine($"验证类型：{user.Identity.AuthenticationType}");
            // to check if the current user belongs to a specific role

            WriteLine($"在管理员组吗？{user.IsInRole(WindowsBuiltInRole.Administrator)}");
            WriteLine($"在管理员组吗？{user.IsInRole(WindowsBuiltInRole.User)}");
            WriteLine($"在管理员组吗？{user.IsInRole("Sales")}");
            WriteLine();
            WriteLine($"{user.Identity.Name} belongs to these roles/groups:");
            foreach (var claim in user.Claims)
            {
                if (claim.Type== "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid")
                {
                    WriteLine($"{claim.Value}:{new SecurityIdentifier(claim.Value).Translate(typeof(NTAccount)).Value}");
                }
            }

            if (user.IsInRole("Administrators"))
            {
                WriteLine("You are in the role so you are allowed access to this feature.");
            }
            else
            {
                WriteLine("You are NOT in the role so you are banned from this feature.");
            }


            // copy the current user principal to the current thread
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            try
            {
                SecureFeature();
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
            ReadLine();
        }

        [PrincipalPermission(SecurityAction.Demand,Role = "Administrators")]
        public static void SecureFeature()
        {
            WriteLine("This is a secure feature!");
        }
    }
}
