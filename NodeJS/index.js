// Tutorial form: https://www.youtube.com/watch?v=1l_5-y_7nTA

const dgram = require('dgram')
const server = dgram.createSocket('udp4')

server.on('error', (error)=>{
    console.log('error on the server \n'+error.message)
    server.close()
})

server.on('listening', ()=>{
    const address = server.address()
    console.log(`server is listenning on ${address.address}:${address.port}`)
})

server.on('message', (message, senderInfo)=>{
    console.log('Message received')
    server.send(message, senderInfo.port, senderInfo.address, ()=>{
        console.log(`Message have been sent to ${senderInfo.address}:${senderInfo.port}`)
    })
})

server.bind(5500)