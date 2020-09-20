## Description
ASP.NET Core Web API which returns Product details on GET request with ability to filter products on certain fields.

## How to run the API
**1. Using dotnet CLI**
```
dotnet restore
dotnet publish -c Release -o out
cd out
dotnet Anacap.Product.API.dll
```
**2. Using Docker**
- Add Dockerfile
```
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Anacap.Product.API.dll"]
```
- Build and Run Container
```
docker build -t productapi .
docker run -d -p 8080:80 --name AnacapProductAPI productapi
```
#### Output from docker commands
```
C:\Users\Administrator\Desktop\New folder>docker build -t productapi .
Sending build context to Docker daemon  48.64kB
Step 1/8 : FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
 ---> b6302fbc90b1
Step 2/8 : WORKDIR /app
 ---> Using cache
 ---> 98669de0b082
Step 3/8 : COPY . ./
 ---> 4822c2c069d8
Step 4/8 : RUN dotnet publish -c Release -o out
 ---> Running in 8cc813abf56e
Microsoft (R) Build Engine version 16.7.0+7fb82e5b2 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\app\Anacap.Product.API\Anacap.Product.API.csproj (in 1.01 min).
  Restored C:\app\Anacap.Product.Test\Anacap.Product.Test.csproj (in 4.14 min).
  Anacap.Product.API -> C:\app\Anacap.Product.API\bin\Release\netcoreapp3.0\Anacap.Product.API.dll
  Anacap.Product.API -> C:\app\out\
  Anacap.Product.Test -> C:\app\Anacap.Product.Test\bin\Release\netcoreapp3.0\Anacap.Product.Test.dll
  Anacap.Product.Test -> C:\app\out\
Removing intermediate container 8cc813abf56e
 ---> 32357890be53
Step 5/8 : FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
3.1: Pulling from dotnet/core/aspnet
ecf9bb62dc6e: Already exists
572c15d276d8: Already exists
05ebe7b26bde: Already exists
9cf7b2c0b888: Already exists
4cda4159bd4d: Already exists
caa51cb29392: Already exists
c551f5febd1f: Already exists
Digest: sha256:adeb306016cb11425faad95b59f138c58910023f5754caeecd815b403330c7a4
Status: Downloaded newer image for mcr.microsoft.com/dotnet/core/aspnet:3.1
 ---> ac08179b581d
Step 6/8 : WORKDIR /app
 ---> Running in b38f66087815
Removing intermediate container b38f66087815
 ---> 1e1abf18de9f
Step 7/8 : COPY --from=build-env /app/out .
 ---> ec719037b4ed
Step 8/8 : ENTRYPOINT ["dotnet", "Anacap.Product.API.dll"]
 ---> Running in 0c5d17c2215f
Removing intermediate container 0c5d17c2215f
 ---> d8603e78839e
Successfully built d8603e78839e
Successfully tagged productapi:latest
```



## Sample Request
1.``` https://localhost:5001/ ``` **GET Request**
- This hits the RootController returning the links to navigate the API.
```json
{
    "href": "https://localhost:5001/",
    "products": "https://localhost:5001/Products"
}
```

2.```https://localhost:5001/Products``` **GET Request**
- This hits the ProductController returning all products
```json
{
  "href": "https://localhost:5001/Products",
  "value": [
    {
            "name": "Intel Free Press",
            "imagee": "https://lh5.ggpht.com/UxT9-J-3vlurwxsQSJWLfdDeflb4NJdyBAcUeBGfVAMHh__ul4ZSTOuHJCrxwQ3DZOM=w300-rw",
            "type": "News & Magazines",
            "rating": 4,
            "price": 0.5,
            "users": 22,
            "lastUpdate": null,
            "description": "Free Press is a tech news site from Intel Corporation, covering technology and innovation stories that are often overlooked or warrant more context and deeper reporting.",
            "url": "https://play.google.com/store/apps/details?id=com.doapps.android.mln.MLN_b85b9817cc7f74e4690e239c65960ee3"
     }
  ]
}
```

3.```https://localhost:5001/Products?type=Productivity``` **GET Request**
- Filters the products based on the parameter
```json
{
  "href": "https://localhost:5001/Products",
  "value": [
        {
            "name": "Security & Antivirus",
            "imagee": "https://lh4.ggpht.com/j79ht2KSJ0O5pydTlCOwNzsnTnSu1tSjO5ahEgROrvcogHE2WZt8sJD9mzG-SA0GRFE=w300-rw",
            "type": "Productivity",
            "rating": 4.3,
            "price": 1.2,
            "users": 272599,
            "lastUpdate": null,
            "description": "McAfee Mobile Security & Antivirus protects and enhances your Android phone or tablet�s performance with award winning Antitheft, Find Device, App Privacy Protection, Antivirus, Battery Optimizer (Extend Battery & Memory Cleanup), and Security features from Intel Security. ",
            "url": "https://play.google.com/store/apps/details?id=com.wsandroid.suite"
        }
     ]
}
```

4.```https://localhost:5001/Products?top=3&page=1&pageSize=5&rating=4.2``` **GET Request**
- Pagination parameters can be passed in the query
```json
{
  "href": "https://localhost:5001/Products",
  "value": [
        {
            "name": "Heartbleed Detector",
            "imagee": "https://lh3.ggpht.com/yUPMZUPu2h1o8oFE349WS0Ucq4KNfFaMDMks6tBRlt2VlTEuXWYLJ7xj26pxZnUdD44=w300-rw",
            "type": "Tools",
            "rating": 4.2,
            "price": 0,
            "users": 922,
            "lastUpdate": null,
            "description": "This app determines if your device or any apps installed on your device are affected by the Heartbleed bug.",
            "url": "https://play.google.com/store/apps/details?id=com.mcafee.heartbleed"
        },
        {
            "name": "Fake ID Detector",
            "imagee": "https://lh3.ggpht.com/iugqqNy_CIyqE_H2uiH84tg2i6F0-wPyHd5aOg2CUBbZgYhLbzSwLtzZwOhf_vvl8HE=w300-rw",
            "type": "Business",
            "rating": 4.2,
            "price": 0,
            "users": 270,
            "lastUpdate": null,
            "description": "Fake ID is an Android vulnerability that allows applications to impersonate other applications by copying their identity that can then be used for malicious purposes.",
            "url": "https://play.google.com/store/apps/details?id=com.mcafee.stinger.fakeid"
        }
     ]
}
```

