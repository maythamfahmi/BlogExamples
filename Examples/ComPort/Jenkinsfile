pipeline {
  agent any
  stages {
    stage('Checkout code') {
      steps {
        echo 'Checking code....'
        echo "Job '${JOB_NAME}' (${BUILD_NUMBER}) is waiting for input"
      }
    }
    stage('Restore packages') {
      steps {
        echo 'Restoring packages....'
        bat 'dotnet restore ComPort.sln'
      }
    }
    stage('Build') {
      steps {
        echo 'Building....'
        bat 'dotnet clean ComPort.sln'
        bat "dotnet build ComPort.sln -c Debug /property:Version=1.0.${BUILD_NUMBER}"
      }
    }
    stage('Test') {
      steps {
        echo 'No Testing....'
      }
    }
    stage('Release') {
      steps {
        echo 'No Release'
      }
    }
    stage('Deploy') {
      parallel {
        stage('Deploy') {
          steps {
            echo 'No Deploy'
          }
        }
        stage('Deploy confirm') {
          steps {
            mail(subject: 'Comport deployed', body: 'xyz', to: 'maythamfahmi@itbackyard.com')
          }
        }
      }
    }
  }
}