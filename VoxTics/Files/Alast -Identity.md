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
