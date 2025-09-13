/Features
├── Account
│   ├── Controllers
│   │   ├── AccountController.cs
│   │   └── ProfileController.cs         <-- جديد
│   ├── Views
│   │   └── Account
│   │       ├── Login.cshtml
│   │       ├── Register.cshtml
│   │       ├── ConfirmOTP.cshtml
│   │       ├── ForgetPassword
│   │       ├── NewPassword
│   │       ├── ResendEmailConfirmation
│   │       └── Profile
│   │           └── Index.cshtml 
            _ExternalAuthenticationPartial
            _ViewImports
            _ViewStart

│   ├── ViewModels
│   │   ├── LoginVM.cs
│   │   ├── RegisterVM.cs
│   │   ├── ConfirmOTPVM.cs
│   │   ├── ForgetPasswordVM.cs
│   │   ├── NewPasswordVM.cs
│   │   ├── PersonalInfoVM.cs
│   │   ├── ResendEmailConfirmationVM.cs
│   │   └── ProfileVM.cs                
│   ├── Services
│   │   ├── Interfaces
│   │   │   └── IApplicationUsersService.cs
                IEmailTemplateService
│   │   └── Implementations
│   │       └── ApplicationUsersService.cs
│   │       └── EmailTemplateService.cs 
│   └── Repositories
│       ├── Interfaces
│       │   └── IApplicationUsersRepository.cs
│       └── Implementations
│           └── ApplicationUsersRepository.cs

/Data
├── MovieDbContext.cs
├── UoW
│   ├── IUnitOfWork.cs
│   └── UnitOfWork.cs

/Repositories
    ├── Interfaces
    │   └── IBaseRepository.cs
    └── Implementations
        └── BaseRepository.cs

/Helpers
├── IEmailService.cs
└── EmailService.cs

/MappingProfiles
├── MappingProfile.cs
└── IdentityProfiles
    └── AccountProfile.cs
