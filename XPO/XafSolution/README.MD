XafSolution is a set of auxiliary or optional projects for *demo purposes* only:

* **XafSolution.Module** is a regular Class Library that defines custom ORM data model classes (*Employee* and *Department*) mapped to database tables. This Class Library is added as an assembly reference to XAF or non-XAF demo apps for different platforms.
To demonstrate a real complex data model, custom ORM classes inherit from standard base classes (*BaseObject* and *Person*) residing in XAF's BCL (*DevExpress.Persistent.BaseImpl*), which is added as a dependency.
The project also contains the helper [Updater class](./XafSolution.Module/DatabaseUpdate/Updater.cs) (see the *CreateUser* and *CreateAdmin* methods) that seeds initial data in the database based on custom ORM classes, all their dependencies (*Party, PhoneNumber*, etc.) and also standard XAF user, role, permission classes from BCL (*PermissionPolicyUser, PermissionPolicyRole*, etc.). For more information, see [Predefined Users, Roles and Permissions](https://docs.devexpress.com/eXpressAppFramework/119065/concepts/security-system/predefined-users-roles-and-permissions).

![](/images/User_Role_Permission_DB.png)

* **XafSolution.Win** is an XAF WinForms UI app that triggers database creation and updates based on data models in *XafSolution.Module* and its dependencies (modify the connection string in the *App.config* file, if required).
You can run this project and log in under 'User' or 'Admin' with an empty password. The WinForms app also demonstrates advanced user, role and permission management as well as built-in authentication and authorization functions in the XAF application UI (it could be WebForms or Blazor UI too).
![](/images/Advanced_XAF_UI_security_features.png)

> **You are NOT obliged to use XafSolution with the same projects, structure and classes if you create real non-XAF apps using XAF's Security System APIs. Instead of XAF IObjectSpace in the Updater class, you can also use XPO UnitOfWork to seed initial data - it's fully up to your development preferences.**
