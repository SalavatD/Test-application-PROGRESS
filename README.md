# Test-application-PROGRESS
Repository with a test app for NPK Progress.

## Running
1. Clone this repository and go to directory:
```
cd Test-application-PROGRESS
```
2. Run container with database:
```
docker run \
  -d \
  -p 5432:5432 \
  --name app-db-pg \
  --env-file ./db/env.list \
  -v "$(pwd)/db/sql":/docker-entrypoint-initdb.d \
  postgres
```
3. Go to `app`:
```
cd app
```
4. Create container with Web App:
```
docker build -t app .
```
5. Run container:
```
docker run -p 80:80 -d app
```
6. Go to [localhost](http://localhost).

## Screens
<details>
<summary>Some screenshots of the app</summary>
<img src="/screens/1.png" width="1000">
<img src="/screens/2.png" width="1000">
<img src="/screens/3.png" width="1000">
<img src="/screens/4.png" width="1000">
<img src="/screens/5.png" width="1000">
</details>
