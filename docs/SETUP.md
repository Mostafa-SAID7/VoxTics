# 🚀 VoxTics Setup Guide

Complete installation, configuration, and database setup instructions for VoxTics.

## Prerequisites

- **.NET 9.0 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/9.0)
- **SQL Server** - LocalDB (included with Visual Studio) or full SQL Server
- **Node.js 18+** - [Download](https://nodejs.org/) (for CSS build tools)
- **Visual Studio 2022** or **VS Code** (recommended)

## Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Mostafa-SAID7/VoxTics.git
cd VoxTics
```

### 2. Install Dependencies

```bash
# Install npm packages (for CSS build tools)
npm install

# Restore .NET packages
dotnet restore
```

### 3. Configure Database Connection

Edit `VoxTics/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=VoxTicsDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"
  }
}
```

**Connection String Options:**

- **LocalDB (Development)**
  ```
  Server=(localdb)\mssqllocaldb;Database=VoxTicsDB;Trusted_Connection=True;
  ```

- **SQL Server Express**
  ```
  Server=.\SQLEXPRESS;Database=VoxTicsDB;Trusted_Connection=True;
  ```

- **Remote SQL Server**
  ```
  Server=your-server.database.windows.net;Database=VoxTicsDB;User Id=username;Password=password;
  ```

### 4. Initialize Database

```bash
cd VoxTics/VoxTics

# Apply migrations
dotnet ef database update

# Or create from scratch
dotnet ef database drop
dotnet ef database update
```

The database will be automatically seeded with initial data on first run.

## Running the Application

### Option 1: Using dotnet CLI

```bash
cd VoxTics/VoxTics
dotnet run
```

The application will start at:
- **Main Site**: https://localhost:7244
- **Admin Panel**: https://localhost:7244/Admin

### Option 2: Using Visual Studio

1. Open `VoxTics.sln` in Visual Studio
2. Set `VoxTics` as the startup project
3. Press `F5` or click **Run**

### Option 3: Using VS Code

```bash
# Install C# extension in VS Code
# Then run:
dotnet run --project VoxTics/VoxTics
```

## Configuration

### Default Admin Account

The system creates a default admin account on first run:

- **Email**: SuperAdmin@gmail.com
- **Password**: Admin123$

**Change the password immediately after first login!**

### Email Configuration

Edit `appsettings.json` to enable email notifications:

```json
{
  "Email": {
    "From": "no-reply@voxtics.com",
    "Smtp": {
      "Host": "smtp.gmail.com",
      "Port": 587,
      "User": "your-email@gmail.com",
      "Pass": "your-app-password"
    }
  }
}
```

**For Gmail:**
1. Enable 2-Factor Authentication
2. Generate an [App Password](https://myaccount.google.com/apppasswords)
3. Use the app password in the configuration

### Stripe Payment Integration

Edit `appsettings.json` to enable Stripe payments:

```json
{
  "Stripe": {
    "PublishableKey": "pk_test_...",
    "SecretKey": "sk_test_..."
  }
}
```

**Get Stripe Keys:**
1. Create a [Stripe Account](https://stripe.com)
2. Go to [API Keys](https://dashboard.stripe.com/apikeys)
3. Copy test keys for development
4. Use live keys for production

**Test Card Numbers:**
- Valid: `4242 4242 4242 4242`
- Declined: `4000 0000 0000 0002`
- Expired: `4000 0000 0000 0069`

### Logging Configuration

Edit `appsettings.json` to configure logging:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  }
}
```

## Database Migrations

### Add a New Migration

```bash
cd VoxTics/VoxTics

# Create migration
dotnet ef migrations add MigrationName

# Apply migration
dotnet ef database update
```

### Remove Last Migration

```bash
dotnet ef migrations remove
```

### View Migration History

```bash
dotnet ef migrations list
```

### Reset Database (Development Only)

```bash
# Drop database
dotnet ef database drop

# Recreate from migrations
dotnet ef database update
```

## Development Setup

### CSS Development

```bash
# Build CSS once
npm run build-css

# Watch CSS files for changes
npm run dev
```

### .NET Development

```bash
# Run with hot reload
dotnet watch run --project VoxTics/VoxTics
```

### Combined Development

```bash
# Terminal 1: Watch CSS
npm run dev

# Terminal 2: Run .NET with hot reload
dotnet watch run --project VoxTics/VoxTics
```

## Troubleshooting

### Database Connection Error

**Error**: `Cannot open database "VoxTicsDB" requested by the login`

**Solution**:
1. Verify SQL Server is running
2. Check connection string in `appsettings.json`
3. Ensure database exists or run migrations

### Migration Error

**Error**: `The migration 'MigrationName' has already been applied to the database`

**Solution**:
```bash
# Remove the migration
dotnet ef migrations remove

# Reapply
dotnet ef database update
```

### Port Already in Use

**Error**: `Address already in use`

**Solution**:
1. Find process using port 7244:
   ```bash
   netstat -ano | findstr :7244
   ```
2. Kill the process:
   ```bash
   taskkill /PID <PID> /F
   ```

### SSL Certificate Error

**Error**: `The SSL connection could not be established`

**Solution**:
1. Trust the development certificate:
   ```bash
   dotnet dev-certs https --trust
   ```
2. Restart the application

### npm Dependencies Error

**Error**: `npm ERR! code ERESOLVE`

**Solution**:
```bash
# Clear npm cache
npm cache clean --force

# Reinstall dependencies
npm install
```

## Production Deployment

### Build for Production

```bash
# Build .NET application
dotnet publish -c Release -o ./publish

# Build CSS for production
npm run build
```

### Deploy to Server

1. Copy the `publish` folder to your server
2. Update `appsettings.Production.json` with production settings
3. Run database migrations on production server
4. Start the application

### Environment-Specific Configuration

Create `appsettings.Production.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=prod-server;Database=VoxTicsDB;User Id=sa;Password=***;"
  },
  "Stripe": {
    "PublishableKey": "pk_live_...",
    "SecretKey": "sk_live_..."
  },
  "Email": {
    "From": "noreply@voxtics.com",
    "Smtp": {
      "Host": "smtp.sendgrid.net",
      "Port": 587,
      "User": "apikey",
      "Pass": "SG...."
    }
  }
}
```

## Verification Checklist

After setup, verify everything is working:

- [ ] Application starts without errors
- [ ] Can access main site at https://localhost:7244
- [ ] Can access admin panel at https://localhost:7244/Admin
- [ ] Can login with default admin account
- [ ] Database is populated with seed data
- [ ] CSS is properly loaded and styled
- [ ] JavaScript console has no errors
- [ ] Can browse movies and cinemas
- [ ] Can add items to cart
- [ ] Payment form loads correctly

## Next Steps

1. **Review Documentation**
   - Read [Architecture Guide](ARCHITECTURE.md)
   - Review [CSS Architecture](CSS.md)
   - Study [JavaScript Architecture](JAVASCRIPT.md)

2. **Explore the Application**
   - Browse movies and cinemas
   - Test booking flow
   - Access admin dashboard
   - Review database schema

3. **Customize for Your Needs**
   - Update branding and colors
   - Configure payment settings
   - Set up email notifications
   - Add your own movies and cinemas

4. **Deploy to Production**
   - Follow production deployment steps
   - Set up SSL certificate
   - Configure database backups
   - Monitor application logs

## Support

For issues or questions:

1. Check the [Troubleshooting](#troubleshooting) section
2. Review application logs in `logs/` directory
3. Check [GitHub Issues](https://github.com/Mostafa-SAID7/VoxTics/issues)
4. Review [Documentation](../README.md)

---

**Last Updated**: May 31, 2026  
**Status**: ✅ Production Ready
