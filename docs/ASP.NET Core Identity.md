# ASP.NET Core Identity 

ASP.Net Core Identity is a user store. 
It contains 
- Password Hashing 
- User and Password Validation
- Password Reset and Email Confirmation
- User Lockout 
- Multi-Factor Authentication
- Enternal Identity Providers

Identity !=Permissions
Identity != Authentication
-- Authentication must be handled by cookies or open id connect tokens 
-- though Identity has auhentication libraries and can be used to validate authentication credentials, 
   it is not responsible for authenctication 
Identity != IdentityServer 
--Identity is user store and IdentityServer offers protocol support for open id connect
