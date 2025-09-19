Register Page → https://localhost:5001/identity/account/register
Login Page → https://localhost:5001/identity/account/login
Forgot Password → https://localhost:5001/identity/account/forgotpassword
Reset Password → https://localhost:5001/identity/account/resetpassword?token=XYZ&email=abc@site.com
Profile Page → https://localhost:5001/identity/account/profile

VoxTics/
│
├─ Areas/
│   ├─ Identity/
│   │   ├─ Controllers/
│   │   │   ├─ AccountController.cs
│   │   │   ├─ ProfileController.cs
│   │   │   └─ ... other Identity controllers
│   │   │
│   │   ├─ Models/
│   │   │   ├─ Entities/
│   │   │   │   ├─ ApplicationUser.cs
│   │   │   │   ├─ UserOTP.cs
│   │   │   │   └─ UserMovieWatchlist.cs
│   │   │   │
│   │   │   └─ ViewModels/
│   │   │       ├─ ConfirmOTPVM.cs
│   │   │       ├─ ForgetPasswordVM.cs
│   │   │       ├─ LoginVM.cs
│   │   │       ├─ ManageProfileVM.cs
│   │   │       ├─ NewPasswordVM.cs
│   │   │       ├─ PersonalInfoVM.cs
│   │   │       ├─ RegisterVM.cs
│   │   │       └─ ResendEmailConfirmationVM.cs
│   │   │
│   │   ├─ Repositories/
│   │   │   ├─ IRepositories/
│   │   │   │   └─ IApplicationUsersRepository.cs
│   │   │   └─ ApplicationUsersRepository.cs
│   │   │
│   │   └─ Services/
│   │       ├─ Interfaces/
│   │       │   └─ IAccountService.cs
│   │       └─ AccountService.cs
│
├─ Data/
│   ├─ MovieDbContext.cs
│   └─ UoW/
│       ├─ IUnitOfWork.cs
│       └─ UnitOfWork.cs
│
├─ Repositories/
│   ├─ IRepositories/
│   │   └─ IBaseRepository.cs
│   └─ BaseRepository.cs
│
├─ Services/
│   └─ ... other general services
│
├─ Helpers/
│   ├─ IEmailService.cs
│   ├─ ImageHelper.cs
│   ├─ PaginatedList.cs
│   ├─ QueryableExtensions.cs
│   └─ ValidationHelpers.cs
│
├─ Mapping/
│   └─ IdentityProfile.cs
│
├─ Controllers/
│   └─ HomeController.cs
│
├─ Views/
│   └─ ... your Razor views
│
├─ TempHtml/
│   ├─ EmailTemplates/
│   │   ├─ WelcomeEmail.html
│   │   ├─ OTPConfirmation.html
│   │   ├─ PasswordReset.html
│   │   └─ ... other temporary HTML templates
│   └─ Notifications/
│       └─ ... optional HTML templates for system notifications
