using System.Security.Cryptography.X509Certificates;

public class MyCertificateValidationService
{
    public bool ValidateCertificate(X509Certificate2 clientCertificate)
    {
        var cert = new X509Certificate2(@"D:\certs\localhost.pfx");
        if (clientCertificate.Thumbprint == cert.Thumbprint)
        {
            return true;
        }

        return false;
    }
}
