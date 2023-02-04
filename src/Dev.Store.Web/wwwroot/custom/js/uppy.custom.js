import Uppy from '/libs/uppy/core';
import XHRUpload from '/libs/uppy/xhr-upload'
import Dashboard from '/libs/uppy/dashboard'


import '/libs/uppy/core/dist/style.css'
import '/libs/suppy/dashboard/dist/style.css'





const uppy = new Uppy()
    .use(Dashboard, {
        trigger: '#select-files',
    })
    .use(XHRUpload, { endpoint: 'https://api2.transloadit.com' })

uppy.on('complete', (result) => {
    console.log('Upload complete! We’ve uploaded these files:', result.successful)
})