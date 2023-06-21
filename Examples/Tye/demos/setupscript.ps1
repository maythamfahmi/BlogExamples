# create the resource group - you may want to change the location to your location
az group create --name rg_Tye --location southcentralus

# register the cluster monitoring extensions
az provider register --namespace Microsoft.OperationsManagement
az provider register --namespace Microsoft.OperationalInsights

# create the cluster
az aks create --resource-group rg_Tye --name Globomantics --node-count 1 --enable-addons monitoring --generate-ssh-keys

# create registery
az acr create -n containerregistry24652 -g rg_Tye --sku basic
az aks update --resource-group rg_Tye --name Globomantics --attach-acr containerregistry24652

# point the local kubectl instance to the Azure cluster
az aks get-credentials --resource-group rg_Tye --name Globomantics