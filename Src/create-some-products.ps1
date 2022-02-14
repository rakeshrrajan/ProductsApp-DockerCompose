function InitiateRequest($requestUrl, $requestBody, $method, $userName, $password, $contentType) {
    $pair = "$($userName):$($password)"
    $encodedCredentials = [System.Convert]::ToBase64String([System.Text.Encoding]::ASCII.GetBytes($pair))
    $authorizationHeaderValue = "Basic $encodedCredentials"
    $headers = @{
        Authorization = $authorizationHeaderValue
    }	
    $body = $requestBody
   
    return Invoke-WebRequest -Uri $requestUrl -Method $method -Body $body -ContentType $contentType -UseBasicParsing
}


function SaveProduct($product){
    
    $url = "http://localhost:8000/api/Product/SaveProducts"    
    
    $payload =  $product | ConvertTo-Json
   
    Write-Host $payload
     
    $contentType = "application/json"

    InitiateRequest -requestUrl $url -method 'POST' -requestBody $payload -contentType $contentType
}

try{

    $products = Import-Csv $PSScriptRoot\Products.csv
        $products | ForEach-Object {
            $product = [PSCustomObject]@{
                productName     = $_.ProductName 
                price = $_.Price -as [Int]
                description    = $_.Description
            } 
           
    
            SaveProduct -product $product
            Write-Host "Product saved success"
        }

}catch {
    
    $errorMessage = "message publish operation failed" + " . Reason - $($_.exception)"
    Write-Host $errorMessage
}

