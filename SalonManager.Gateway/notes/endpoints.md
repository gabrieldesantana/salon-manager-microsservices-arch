GET https://localhost:7002/api/Appointments/{tenantId}/{id} OK [Authorize(Roles = "Owner,Employee,Admin")]

DELETE https://localhost:7002/api/Appointments/{tenantId}/{id} [Authorize(Roles = "Owner,Employee,Admin")]

GET https://localhost:7002/api/Appointments/{tenantId} OK [Authorize(Roles = "Owner,Employee,Admin")]

GET https://localhost:7002/api/Appointments/{tenantId}/customer/{customerId} OK [Authorize(Roles = "Owner,Employee,Admin,Customer")]

GET https://localhost:7002/api/Appointments/{tenantId}/employee/{employeeId} OK [Authorize(Roles = "Owner,Admin")]

GET https://localhost:7002/api/Appointments/{tenantId}/allFinished?startDate={}&endDate={}' [Authorize(Roles = "Owner,Admin")]

POST https://localhost:7002/api/Appointments OKK  [Authorize(Roles = "Owner,Employee,Admin")]

PUT https://localhost:7002/api/Appointments OK [Authorize(Roles = "Owner,Employee,Admin")]

PUT https://localhost:7002/api/Appointments/finish ???? [Authorize(Roles = "Owner,Employee,Admin")]

PATCH https://localhost:7002/api/Appointments/update-status OK  [Authorize(Roles = "Owner,Employee,Admin")]



GET https://localhost:7002/api/Companies/{tenantId}/{id} OK [Authorize(Roles = "Admin")]

GET https://localhost:7002/api/Companies OK [Authorize(Roles = "Admin")]

DELETE https://localhost:7002/api/Companies/{tenantId}/{id} [Authorize(Roles = "Admin")]

POST https://localhost:7002/api/Companies OKK [Authorize(Roles = "Admin")]

PUT https://localhost:7002/api/Companies OK [Authorize(Roles = "Admin")]


GET https://localhost:7002/api/Customers/{tenantId}/{id} OK [Authorize(Roles = "Owner,Employee,Admin")]

GET https://localhost:7002/api/Customers/{tenantId} OK [Authorize(Roles = "Owner,Employee,Admin")]

DELETE https://localhost:7002/api/Customers/{tenantId}/{id} [Authorize(Roles = "Owner,Employee,Admin")]

POST https://localhost:7002/api/Customers OKK [Authorize(Roles = "Owner,Employee,Admin")]

PUT https://localhost:7002/api/Customers OK [Authorize(Roles = "Owner,Employee,Admin")]

PUT https://localhost:7002/api/Customers/increase-visited-times [Authorize(Roles = "Owner,Employee")]


GET https://localhost:7002/api/Employees/{tenantId}/{id} OK [Authorize(Roles = "Owner,Admin")]

DELETE https://localhost:7002/api/Employees/{tenantId}/{id} [Authorize(Roles = "Owner,Admin")]

GET https://localhost:7002/api/Employees/{tenantId} OK [Authorize(Roles = "Owner,Admin")]
 
POST https://localhost:7002/api/Employees OKK [Authorize(Roles = "Owner,Admin")]

PUT https://localhost:7002/api/Employees OK [Authorize(Roles = "Owner,Admin")]


GET https://localhost:7002/api/SalonServices/{tenantId}/{id} OK [Authorize(Roles = "Owner,Employee,Admin")]

DELETE https://localhost:7002/api/SalonServices/{tenantId}/{id} OK [Authorize(Roles = "Owner,Employee,Admin")]

GET https://localhost:7002/api/SalonServices/{tenantId} OK [Authorize(Roles = "Owner,Employee,Admin")]
 
POST https://localhost:7002/api/SalonServices OKK [Authorize(Roles = "Owner,Employee,Admin")]

PUT https://localhost:7002/api/SalonServices OK [Authorize(Roles = "Owner,Employee,Admin")]


GET https://localhost:7002/api/Users/{id} OK [Authorize(Roles = "Admin")]

DELETE https://localhost:7002/api/Users/{id}  OK [Authorize(Roles = "Admin")]

GET https://localhost:7002/api/Users OK [Authorize(Roles = "Admin")]

POST https://localhost:7002/api/Users OKK [Authorize(Roles = "Admin")]

PUT https://localhost:7002/api/Users OK [Authorize(Roles = "Admin")]

PUT https://localhost:7002/api/Users/activate-user [Authorize(Roles = "Owner,Employee,Admin")]



SERA NECESSARIO CRIAR V2 PARA AS SEGUINTES IMAGES:

BUSINESS
APPOINTMENTS
CUSTOMERS

PARA ATUALIZAR A CONFIGURACAO DO JWT NO APPSETTINGS PROD




#$secretName = kubectl -n salonmanager-hom-ns get sa/default -o jsonpath="{.secrets[0].name}"
#$encodedToken = kubectl -n salonmanager-hom-ns get secret $secretName -o jsonpath="{.data.token}"

#Write-Output $encodedToken

#$decodedToken = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($encodedToken))
#$decodedToken


# Obter o nome do secret associado ao ServiceAccount
$secretName = kubectl -n salonmanager-hom-ns get sa/ocelot-service-account -o jsonpath="{.secrets[0].name}"

# Verificar se o nome do secret foi obtido corretamente
if ($secretName) {
    # Obter o token codificado em base64
    $encodedToken = kubectl -n salonmanager-hom-ns get secret $secretName -o jsonpath="{.data.token}"
    
    # Verificar se o token foi obtido corretamente
    if ($encodedToken) {
        # Decodificar o token de base64 para uma string legível
        $decodedToken = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($encodedToken))
        $decodedToken
    } else {
        Write-Host "Erro: Não foi possível obter o token do secret."
    }
} else {
    Write-Host "Erro: Não foi possível obter o nome do secret associado ao ServiceAccount."
}
