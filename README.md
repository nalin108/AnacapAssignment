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

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

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
docker build -t productAPI .
docker run -d -p 8080:80 -p 5001:5001 --name AnacapProductAPI productAPI
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

