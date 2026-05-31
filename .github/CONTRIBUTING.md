# Contributing to VoxTics

Thank you for your interest in contributing to VoxTics! We welcome contributions from the community.

## Getting Started

1. **Fork** the repository on GitHub
2. **Clone** your fork locally:
   ```bash
   git clone https://github.com/YOUR_USERNAME/VoxTics.git
   cd VoxTics
   ```
3. **Create a feature branch**:
   ```bash
   git checkout -b feature/your-feature-name
   ```

## Development Setup

### Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB for development)
- Node.js 18+

### Setup Instructions
1. Navigate to the project directory
2. Install npm dependencies:
   ```bash
   npm install
   ```
3. Build CSS:
   ```bash
   npm run build-css
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

## Code Standards

### C# Code
- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use PascalCase for class names and public members
- Use camelCase for local variables and parameters
- Add XML documentation comments for public APIs

### CSS/Styling
- Use CSS custom properties for theming
- Follow the Apple Keyboard+ Design System guidelines
- Ensure responsive design (mobile-first approach)
- Test in both light and dark modes

### JavaScript
- Use modern ES6+ syntax
- Follow consistent naming conventions
- Add comments for complex logic
- Ensure accessibility compliance

### HTML/Razor Views
- Use semantic HTML
- Include proper ARIA attributes for accessibility
- Follow WCAG 2.1 AA standards

## Testing

- Write unit tests for new features
- Ensure all tests pass before submitting a PR:
  ```bash
  dotnet test
  ```

## Commit Guidelines

- Use clear, descriptive commit messages
- Start with a verb: "Add", "Fix", "Update", "Remove", etc.
- Example: `Add seat selection feature for cinema bookings`
- Reference issues when applicable: `Fix #123`

## Pull Request Process

1. **Update your branch** with the latest main:
   ```bash
   git fetch origin
   git rebase origin/main
   ```

2. **Push your changes**:
   ```bash
   git push origin feature/your-feature-name
   ```

3. **Create a Pull Request** on GitHub with:
   - Clear title describing the changes
   - Description of what was changed and why
   - Reference to related issues
   - Screenshots for UI changes

4. **Address feedback** from reviewers

5. **Ensure CI/CD passes** before merge

## Reporting Issues

- Use GitHub Issues to report bugs
- Include:
  - Clear description of the issue
  - Steps to reproduce
  - Expected vs actual behavior
  - Environment details (OS, .NET version, etc.)
  - Screenshots if applicable

## Feature Requests

- Use GitHub Discussions for feature ideas
- Describe the use case and benefits
- Provide examples if possible

## Questions?

- Check existing documentation in `/docs`
- Review closed issues and discussions
- Open a new discussion for questions

## License

By contributing to VoxTics, you agree that your contributions will be licensed under the MIT License.

Thank you for contributing to VoxTics! 🎬
