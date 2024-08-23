FROM node:20.13.1-alpine
ENV TZ=UTC 
WORKDIR /app

COPY ./package.json /app

RUN npm install

COPY . .

CMD ["npm", "run", "dev"]