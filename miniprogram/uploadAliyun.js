const env = require('./config.js');
const Base64 = require('./Base64.js');

require('./crypto/hmac.js');
require('./crypto/sha1.js');
const Crypto = require('./crypto/crypto.js');

const uploadFile = function (filePath, targetPath, successcb, failcb) {

    const aliyunFileKey = targetPath;
    const aliyunServerURL = env.uploadImageUrl;
    const accessid = env.accessid;
    const policyBase64 = getPolicyBase64();
    const signature = getSignature(policyBase64);

    console.log('signature=', signature);
    console.log('aliyunFileKey=', aliyunFileKey);

    wx.uploadFile({
        url: aliyunServerURL,
        filePath: filePath,
        name: 'file',
        formData: {
            'key': aliyunFileKey,
            'OSSAccessKeyId': accessid,
            'policy': policyBase64,
            'Signature': signature,
            'success_action_status': '200',
        },
        success: function (res) {
          console.log('uploadFile.success ', res.data)
          successcb(res)
          if (res.statusCode != 200) {
            console.log(res.data)
              return;
          }
        },
        fail: function (err) {
          failcb(err)
          err.wxaddinfo = aliyunServerURL;
          console.log('uploadFile.fail', err);
        },
    })
}

const getPolicyBase64 = function () {
    let date = new Date();
    date.setHours(date.getHours() + env.timeout);
    let srcT = date.toISOString();
    const policyText = {
        "expiration": srcT, //设置该Policy的失效时间，超过这个失效时间之后，就没有办法通过这个policy上传文件了 指定了Post请求必须发生在2020年01月01日12点之前("2020-01-01T12:00:00.000Z")。
        "conditions": [
            ["content-length-range", 0, 20 * 1024 * 1024] // 设置上传文件的大小限制,1048576000=1000mb
        ]
    };

    const policyBase64 = Base64.encode(JSON.stringify(policyText));
    return policyBase64;
}

const getSignature = function (policyBase64) {
    const accesskey = env.accesskey;

    const bytes = Crypto.HMAC(Crypto.SHA1, policyBase64, accesskey, {
        asBytes: true
    });
    const signature = Crypto.util.bytesToBase64(bytes);

    return signature;
}

module.exports = uploadFile;