const app = getApp()
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
      passportInfo: wx.getStorageSync('passportInfo')
    })
  },

  inputOtherinfophone: function (e) {
    this.setData({
      ['passportInfo.details.phone']: e.detail.value
    })
  },
  inputOtherinfoaddress: function (e) {
    this.setData({
      ['passportInfo.details.address']: e.detail.value
    })
  },
  inputOtherinfoemail: function (e) {
    this.setData({
      ['passportInfo.details.email']: e.detail.value
    })
  },
  inputOtherinfooccupation: function (e) {
    this.setData({
      ['passportInfo.details.occupation']: e.detail.value
    })
  },
  inputOtherinfofather_name: function (e) {
    this.setData({
      ['passportInfo.details.father_name']: e.detail.value
    })
  },
  inputOtherinfomother_name: function (e) {
    this.setData({
      ['passportInfo.details.mother_name']: e.detail.value
    })
  },

  submit:function() {
    console.log(this.data.passportInfo)
    wx.request({
      url: 'https://fan.blockai.me/save_passport.php',
      data: this.data.passportInfo,
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
    wx.setStorageSync('passportInfo', this.data.passportInfo)
  },

  /**
   * Lifecycle function--Called when page unload
   */
  onUnload: function () {
    wx.setStorageSync('passportInfo', this.data.passportInfo)
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