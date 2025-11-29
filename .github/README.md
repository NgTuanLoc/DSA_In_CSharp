# GitHub Actions CI/CD Setup

This repository uses GitHub Actions for continuous integration and deployment.

## Workflow

### .NET CI (`dotnet-ci.yml`)
Single unified workflow that runs on every push and pull request to `master`, `main`, or `develop` branches.

**Steps:**
- Checkout code
- Setup .NET 10.0
- Restore dependencies
- Build solution in Release mode
- Run all tests with code coverage
- Upload test results as artifacts
- Generate test summary report
- Generate code coverage report in markdown
- Post coverage summary as PR comment (on PRs only)
- Upload coverage artifacts

**Features:**
- ✅ Build + Test + Coverage in one job
- ✅ No external services required - uses built-in .NET coverage tools
- ✅ Automatically comments on PRs with test and coverage summary
- ✅ Generates coverage badge
- ✅ Sets thresholds (60% warning, 80% good)
- ✅ Shows branch and complexity metrics
- ✅ Test results with detailed reporting

**Badge:**
```markdown
[![.NET CI](https://github.com/NgTuanLoc/DSA_In_CSharp/actions/workflows/dotnet-ci.yml/badge.svg)](https://github.com/NgTuanLoc/DSA_In_CSharp/actions/workflows/dotnet-ci.yml)
```

## Local Testing

Test the workflows locally before pushing:

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Build in Release mode (as CI does)
dotnet build --configuration Release
```

## Viewing Results

- **Action runs**: Go to the `Actions` tab in your GitHub repository
- **Test results**: Check the workflow run details for test summary
- **Coverage**: Visit Codecov dashboard after setup

## Customization

### Add more .NET versions
Edit the matrix in `dotnet-ci.yml`:
```yaml
strategy:
  matrix:
    dotnet-version: ['8.0.x', '9.0.x', '10.0.x']
```

### Run on different branches
Modify the `on` section:
```yaml
on:
  push:
    branches: [ your-branch-name ]
```

### Add build artifacts
Add after the build step:
```yaml
- name: Upload build artifacts
  uses: actions/upload-artifact@v4
  with:
    name: build-artifacts
    path: src/DSA/bin/Release/
```
