pipeline {
  agent {
    label 'windows'
  }

  environment {
    NUGET_EXE = 'nuget.exe'
  }

  stages {
    stage('Checkout') {
      steps {
        checkout scm
      }
    }
     stage('Info') {
      steps {
        bat "echo %PATH%"
      }
    }
    stage('Restore NuGet packages') {
      steps {
        bat "nuget restore MatKinhShadyTest.sln"
      }
    }

    stage('Build solution') {
      steps {
        bat "dotnet build MatKinhShadyTest.sln --configuration Release --no-restore"
      }
    }

    stage('Run tests') {
      steps {
        bat "dotnet test MatKinhShadyTest.sln --no-build --verbosity normal"
      }
    }
  }

  post {
    always {
      junit '**/ReportResults/*.html' // Optional: if you want test results in Jenkins
    }
  }
}
