const uploadFile = require('../../uploadAliyun.js')
Page({

  /**
   * Page initial data
   */
  data: {

  },

  /**
   * Lifecycle function--Called when page load
   */
  onLoad: function (options) {

  },

  /**
   * Lifecycle function--Called when page is initially rendered
   */
  onReady: function () {

  },

  /**
   * Lifecycle function--Called when page show
   */
  onShow: function () {

  },

  /**
   * Lifecycle function--Called when page hide
   */
  onHide: function () {

  },

  /**
   * Lifecycle function--Called when page unload
   */
  onUnload: function () {

  },

  /**
   * Page event handler function--Called when user drop down
   */
  onPullDownRefresh: function () {

  },

  /**
   * Called when page reach bottom
   */
  onReachBottom: function () {

  },

  doUploadPhoto: function () {
    wx.chooseImage({
      count: 1,
      sizeType: ['compressed'],
      sourceType: ['album', 'camera'],
      success: function (res) {
        var tempFilePaths = res.tempFilePaths

        var passportInfo = wx.getStorageSync('passportInfo')
        var photoFileName = 'photo/' + passportInfo.passport_no + '_photo.' + tempFilePaths[0].split('.').pop()

        console.log('uploading ', photoFileName)

        uploadFile(tempFilePaths[0], photoFileName)
        
        console.log('uploaded ', photoFileName)
      },
      fail: e => {
        console.error(e)
      }
    })
  },
  /**
   * Called when user click on the top right corner to share
   */
  onShareAppMessage: function () {

  }
})