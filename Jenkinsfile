node('master') {
    stage('import') {
        git 'https://github.com/1804-Apr-USFdotnet/cameron-wagstaff-project1.git'
    }
    stage('build') {
        dir('WebReviewSite'){
            bat 'nuget restore'
            bat 'msbuild /p:MvcBuildViews=true'
        }
    }
    stage('test') {
        bat "VSTest.Console WebReviewSite\\WebReviewSite.Tests\\bin\\Debug\\WebReviewSite.Tests.dll"
    }
    stage('analyze') {
        
    }
    stage('package') {
        dir('WebReviewSite') {
            bat 'msbuild WebReviewSite /t:package'
        }
    }
    stage('deploy') {
        dir('WebReviewSite') {
            dir('WebReviewSite/obj/Debug/Package') {
                bat "\"C:\\Program Files\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe\" -source:package='C:\\Program Files (x86)\\Jenkins\\workspace\\project1\\WebReviewSite\\WebReviewSite\\obj\\Debug\\Package\\WebReviewSite.zip' -dest:auto,computerName=\"https://ec2-18-188-110-139.us-east-2.compute.amazonaws.com:8172/msdeploy.axd\",userName=\"Administrator\",password=\"${env.DEPLOY_PK}\",authtype=\"basic\",includeAcls=\"False\" -verb:sync -disableLink:AppPoolExtension -disableLink:ContentExtension -disableLink:CertificateExtension -setParamFile:\"C:\\Program Files (x86)\\Jenkins\\workspace\\project1\\WebReviewSite\\WebReviewSite\\obj\\Debug\\Package\\WebReviewSite.SetParameters.xml\" -AllowUntrusted=True"
            }
        }
    }
}