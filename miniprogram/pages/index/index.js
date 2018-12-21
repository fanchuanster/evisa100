//index.js
const app = getApp()

Page({
  data: {
    avatarUrl: './user-unlogin.png',
    userInfo: {},
    logged: false,
    takeSession: false,
    requestResult: ''
  },

  onLoad: function() {
    console.log('index.js.onLoad')
    if (!wx.cloud) {
      wx.redirectTo({
        url: '../chooseLib/chooseLib',
      })
    }

    wx.cloud.callFunction({
        name: 'login',
        data: {},
        success: res => {
          console.log('[云函数] [login] user openid: ', res.result.openid)
          app.globalData.openid = res.result.openid
        },
        fail: err => {
          console.error('[云函数] [login] 调用失败', err)
          wx.navigateTo({
            url: '../deployFunctions/deployFunctions',
          })
        }
      })
      
      return
    },

    // 获取用户信息
    // wx.getSetting({
    //   success: res => {
    //     if (res.authSetting['scope.userInfo']) {
    //       // 已经授权，可以直接调用 getUserInfo 获取头像昵称，不会弹框
    //       wx.getUserInfo({
    //         success: res => {
    //           console.log(res.userInfo)
    //           this.setData({
    //             avatarUrl: res.userInfo.avatarUrl,
    //             userInfo: res.userInfo
    //           })
    //         }
    //       })
    //     }
    //   }
    // })
  

  onGetUserInfo: function(e) {
    if (!this.logged && e.detail.userInfo) {
      this.setData({
        logged: true,
        avatarUrl: e.detail.userInfo.avatarUrl,
        userInfo: e.detail.userInfo
      })
    }
  },

  onGetOpenid: function() {
    // 调用云函数
    wx.cloud.callFunction({
      name: 'login',
      data: {},
      success: res => {
        console.log('[云函数] [login] user openid: ', res.result.openid)
        app.globalData.openid = res.result.openid
         wx.navigateTo({
          url: '../userConsole/userConsole',
        })
      },
      fail: err => {
        console.error('[云函数] [login] 调用失败', err)
        wx.navigateTo({
          url: '../deployFunctions/deployFunctions',
        })
      }
    })
  },

  doUploadPassport: function () {
    // 选择图片
    wx.chooseImage({
      count: 1,
      sizeType: ['compressed'],
      sourceType: ['album', 'camera'],
      success: function (res) {

        wx.showLoading({
          title: 'OCR ing...',
        })

        const imagePath = res.tempFilePaths[0]
        const fs = wx.getFileSystemManager()
        fs.readFile({
          filePath: imagePath, 
          encoding:'base64',
          success: function(res) {
            var data = res.data
            wx.request({
              url: 'https://ocrdiy.market.alicloudapi.com/api/predict/ocr_sdt_err',
              data: {
                image: data,
                configure: { template_id:"e132cad9-55e9-417f-9111-c82d3105ed501545292863"}
              },
              method: 'POST',
              header: {
                'content-type': 'application/json; charset=UTF-8',
                'Authorization': "APPCODE 391037852026434fa5c6e3780ef61220"
              },
              success: function (res) {
                var objstr = '{"config_str":{"template_id":"e132cad9-55e9-417f-9111-c82d3105ed501545292863"},"items":{"authority":"MPS Exit&Entry Administration","authority_cn":"公安部出入境管理局","birth_date":"25","birth_place":"湖北/HUBEI","country_code":"CHN","expiry_date":"062月/FEB2024","issue_date":"07 2月/FEB 2014","issue_place":"上海/SHANGHAI","name":"DONG,WEN","name_cn":"董文","nationality":"中国/CHINESE","passport_no":"E06279103","sex":"男/M","type":"P"},"request_id":"20181221174315_5bfa13c25816d99985e25694c498dc52","success":true}'
                
                res.data = JSON.parse(objstr)
                
                wx.setStorageSync('passportInfo', res.data.items)
                wx.navigateTo({
                  url: '../passportInfo/passportInfo',
                })                
              },
              error: function (res) {
                console.log(res.err)
              }
            })
          },
          fail: function(res) {
            console.log(res.errMsg)
          }
        })
      },
      fail: e => {
        console.error(e)
      },
      complete: () => {
        wx.hideLoading()
      }
    })
  },
})
