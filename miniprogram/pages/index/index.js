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
    if (!wx.cloud) {
      wx.redirectTo({
        url: '../chooseLib/chooseLib',
      })

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
      
      return
    }

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
  },

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
              url: 'https://ocrhz.market.alicloudapi.com/rest/160601/ocr/ocr_passport.json_error',
              data: {
                image: data
              },
              method: 'POST',
              header: {
                'content-type': 'application/json; charset=UTF-8',
                'Authorization': "APPCODE 391037852026434fa5c6e3780ef61220"
              },
              success: function (res) {
                var objstr = '{"authority":"公安部出入境管理局","birth_date":"19840125","birth_day":"840125","birth_place":"湖北","birth_place_raw":"湖北/HUBEI","country":"CHN","expiry_date":"20240206","expiry_day":"240206","issue_date":"20140207","issue_place":"上海","issue_place_raw":"上海/SHANGHAI","line0":"POCHNDONG<<WEN<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<","line1":"E062791038CHN8401256M2402066LGKNMOME<<<<A994","name":"DONG.WEN","name_cn":"董文","name_cn_raw":"DONGHEN董文","passport_no":"E06279103","person_id":"LGKNMOME<<<<A9","request_id":"20181213181912_b4c9daa1c5f4c2ac6924f53c364119e2","sex":"M","src_country":"CHN","success":true,"type":"PO"}'
                res.data = (JSON.parse(objstr))

                wx.setStorageSync('passportInfo', res.data)
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
