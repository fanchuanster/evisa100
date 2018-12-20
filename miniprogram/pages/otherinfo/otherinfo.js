Page({

  /**
   * Page initial data
   */
  data: {
    otherinfo:null
  },

  /**
   * Lifecycle function--Called when page load
   */
  onLoad: function (options) {
    this.setData({
      otherinfo: wx.getStorageSync('otherinfo')
    })
  },

  inputOtherinfophone: function (e) {
    this.setData({
      ['otherinfo.phone']: e.detail.value
    })
  },
  inputOtherinfoaddress: function (e) {
    this.setData({
      ['otherinfo.address']: e.detail.value
    })
  },
  inputOtherinfoemail: function (e) {
    this.setData({
      ['otherinfo.email']: e.detail.value
    })
  },
  inputOtherinfooccupation: function (e) {
    this.setData({
      ['otherinfo.occupation']: e.detail.value
    })
  },
  inputOtherinfofather_name: function (e) {
    this.setData({
      ['otherinfo.father_name']: e.detail.value
    })
  },
  inputOtherinfomother_name: function (e) {
    this.setData({
      ['otherinfo.mother_name']: e.detail.value
    })
  },

  submit:function() {

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
    wx.setStorageSync('otherinfo', this.data.otherinfo)
  },

  /**
   * Lifecycle function--Called when page unload
   */
  onUnload: function () {
    wx.setStorageSync('otherinfo', this.data.otherinfo)
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