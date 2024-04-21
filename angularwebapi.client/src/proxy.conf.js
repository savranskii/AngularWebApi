const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7207';

const PROXY_CONFIG = [
  {
    context: [
      "/api/v1/user/registration",
      "/api/v1/user/locations"
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
