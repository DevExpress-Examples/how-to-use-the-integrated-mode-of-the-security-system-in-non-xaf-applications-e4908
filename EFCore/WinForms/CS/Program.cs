﻿using BusinessObjectsLibrary.EFCore.BusinessObjects;
using DevExpress.EntityFrameworkCore.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace WindowsFormsApplication {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            AuthenticationStandard authentication = new AuthenticationStandard();
            SecurityStrategyComplex security = new SecurityStrategyComplex(
                typeof(PermissionPolicyUser), typeof(PermissionPolicyRole),
                authentication
            );
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SecuredEFCoreObjectSpaceProvider objectSpaceProvider = new SecuredEFCoreObjectSpaceProvider(security, typeof(ApplicationDbContext),
                (builder, _) => builder.UseSqlServer(connectionString));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm(security, objectSpaceProvider);
            Application.Run(mainForm);
        }
    }
}
