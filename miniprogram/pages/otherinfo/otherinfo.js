Page({

  /**
   * Page initial data
   */
  data: {
    passportInfo:null
  },

  /**
   * Lifecycle function--Called when page load
   */
  onLoad: function (options) {
    this.setData({
      passportInfo: wx.getStorageSync('otherinfo')
    })
  },

  inputOtherinfophone: function (e) {
    this.setData({
      ['passportInfo.phone']: e.detail.value
    })
  },
  inputOtherinfoaddress: function (e) {
    this.setData({
      ['otherinfo.address']: e.detail.value
    })
  },
  inputOtherinfoemail: function (e) {
    this.setData({
      ['passportInfo.email']: e.detail.value
    })
  },
  inputOtherinfooccupation: function (e) {
    this.setData({
      ['passportInfo.occupation']: e.detail.value
    })
  },
  inputOtherinfofather_name: function (e) {
    this.setData({
      ['passportInfo.father_name']: e.detail.value
    })
  },
  inputOtherinfomother_name: function (e) {
    this.setData({
      ['passportInfo.mother_name']: e.detail.value
    })
  },

  submit:function() {
    wx.request({
      url: 'https://fan.blockai.me/save_passport.php',
      data: {
        passport_no: this.data.passportInfo.passport_no,
        openid: app.globalData.openid,
        details: this.data.passportInfo
      },
      method: 'POST',
      header: {
        'content-type': 'application/json; charset=UTF-8'
      },
      success: function (res) {
        console.log(res)
      },
      error: function (res) {
        console.log(res.err)
      }
    })
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
    wx.setStorageSync('passportInfo', this.data.otherinfo)
  },

  /**
   * Lifecycle function--Called when page unload
   */
  onUnload: function () {
    wx.setStorageSync('passportInfo', this.data.otherinfo)
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

  /**
   * Called when user click on the top right corner to share
   */
  onShareAppMessage: function () {

  }
})