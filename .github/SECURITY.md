# Security Policy

## Reporting a Vulnerability

If you discover a security vulnerability in VoxTics, please **do not** open a public GitHub issue. Instead, please report it responsibly by:

1. **Email**: Send details to security@voxtics.com (or project maintainers)
2. **GitHub Security Advisory**: Use GitHub's [Report a security vulnerability](https://github.com/VoxTics/VoxTics/security/advisories/new) feature

Please include:
- Description of the vulnerability
- Steps to reproduce
- Potential impact
- Suggested fix (if available)

## Security Best Practices

### For Users
- Keep your .NET runtime updated
- Use strong passwords for admin accounts
- Enable HTTPS in production
- Regularly update dependencies
- Use environment variables for sensitive configuration

### For Developers
- Never commit secrets or API keys
- Use parameterized queries to prevent SQL injection
- Validate and sanitize all user inputs
- Follow OWASP security guidelines
- Keep dependencies updated
- Use security headers in production

## Supported Versions

| Version | Supported          |
|---------|-------------------|
| 1.x     | ✅ Supported      |
| < 1.0   | ❌ Not Supported  |

## Security Updates

Security updates will be released as soon as possible after a vulnerability is confirmed. We recommend:
- Subscribing to release notifications
- Regularly checking for updates
- Testing updates in a staging environment before production deployment

## Dependencies

VoxTics uses the following key dependencies:
- ASP.NET Core 9.0
- Entity Framework Core 9.0
- Stripe.net
- TailwindCSS

We regularly audit and update these dependencies. Check `package.json` and `.csproj` files for current versions.

## Compliance

VoxTics aims to comply with:
- OWASP Top 10 security practices
- WCAG 2.1 accessibility standards
- Data protection regulations (GDPR, etc.)

## Questions?

For security-related questions, please contact the maintainers directly rather than opening public issues.

Thank you for helping keep VoxTics secure! 🔒
