pipeline {
  agent any
  triggers { pollSCM('*/1 * * * *') }
  parameters {
    		string(name: 'JOBSERVICE_MAJOR_VERSION', defaultValue: '0', description: 'Only integers!')
    		string(name: 'JOBSERVICE_MINOR_VERSION', defaultValue: '1', description: 'Only integers!')
			string(name: 'PRETTY_APPLICATION_NAME', defaultValue: 'JobService', description: 'No whitespaces!')
	}
	environment {
			APPLICATION_NAME = "${params.PRETTY_APPLICATION_NAME.toLowerCase()}"
    		BUILD_VERSION = "${params.JOBSERVICE_MAJOR_VERSION}.${params.JOBSERVICE_MINOR_VERSION}.${BUILD_NUMBER}"
			DOCKER_IMAGE_NAME = "${BRANCH_NAME}/${APPLICATION_NAME}" 
	}
	stages {
		stage('Configure') {
			steps {
				sh "env"
			}
		}

		stage('Create Dockerfile') {
			steps {
				script {
					
					withCredentials(
						[
							string(credentialsId: '2052f7ea-e4ba-4f9b-8ea9-7508667db5a5', variable: 'DTRURL')
						]
					){
					sh """
						
						docker info
						echo "----------------------------------------------------------------------------------------"
						echo $DTRURL/$DOCKER_IMAGE_NAME

						docker build . \
						  -t $DOCKER_IMAGE_NAME:${BUILD_VERSION} \
						  -t $DOCKER_IMAGE_NAME:latest \
						  -t $DTRURL:${BUILD_VERSION} \
						  -t $DTRURL:latest
						docker images 
					"""
					}	
				}
			}
		}
		
		stage('Push Dockerfile') {
			steps {
				script {
					DOCKER_TLS_VERIFY=0
					
					withCredentials(
						[
							usernamePassword(credentialsId: 'd820af03-6268-41f7-a649-6c4ea0f2983e', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD'),
							string(credentialsId: '2052f7ea-e4ba-4f9b-8ea9-7508667db5a5', variable: 'DTRURL')
						]
					){
						sh """
							set +x
							echo 'logging in to $DTRURL'
							docker login -u $USERNAME -p $PASSWORD
							set -x
							# docker push
							docker push $DTRURL:${BUILD_VERSION}
							docker push $DTRURL:latest
						"""
					}
				}
			}
		}
	}
}
