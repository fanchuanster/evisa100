// miniprogram/pages/passportInfo/passportInfo.js
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
      passportInfo : wx.getStorageSync('passportInfo')
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

  inputPassportNo: function (e) {
    this.setData({
      ['passportInfo.passport_no']: e.detail.value
    })
  },
  inputPassportcountry: function (e) {
    this.setData({
      ['passportInfo.nationality']: e.detail.value
    })
  },

  inputPassporttype: function (e) {
    this.setData({
      ['passportInfo.type']: e.detail.value
    })
  },

  inputPassportname_cn: function (e) {
    this.setData({
      ['passportInfo.name_cn']: e.detail.value
    })
  },
  inputPassportname: function (e) {
    this.setData({
      ['passportInfo.name']: e.detail.value
    })
  },
  inputPassportinputPassportsextype: function (e) {
    this.setData({
      ['passportInfo.sex']: e.detail.value
    })
  },
  inputPassportbirth_date: function (e) {
    this.setData({
      ['passportInfo.birth_date']: e.detail.value
    })
  },
  inputPassportbirth_place: function (e) {
    this.setData({
      ['passportInfo.birth_place']: e.detail.value
    })
  },

  inputPassportauthority: function (e) {
    this.setData({
      ['passportInfo.authority']: e.detail.value
    })
  },
  inputPassportissue_date: function (e) {
    this.setData({
      ['passportInfo.issue_date']: e.detail.value
    })
  },
  inputPassportexpiry_date: function (e) {
    this.setData({
      ['passportInfo.expiry_date']: e.detail.value
    })
  },
  inputPassportissue_place: function (e) {
    this.setData({
      ['passportInfo.issue_place']: e.detail.value
    })
  },
  
  /**
   * Lifecycle function--Called when page hide
   */
  onHide: function () {
    wx.setStorageSync('passportInfo', this.data.passportInfo)
  },

  nextToUploadPhoto: function() {
    wx.request({
      url: 'http://139.196.98.92/save_passport.php',
      data: {
        id: this.data.passportInfo.id,
        passport_no: this.data.passportInfo.passport_no,
        name: this.data.passportInfo.name,
        name_cn: this.data.passportInfo.name_cn,
        sex: this.data.passportInfo.sex,
        birth_date: this.data.passportInfo.birth_date,
        birth_place: this.data.passportInfo.birth_place,
        birth_place_raw: this.data.passportInfo.birth_place_raw,
        country: this.data.passportInfo.country,
        type: this.data.passportInfo.type,
        authority: this.data.passportInfo.authority,
        issue_date: this.data.passportInfo.issue_date,
        issue_place: this.data.passportInfo.issue_place,
        issue_place_raw: this.data.passportInfo.issue_place_raw,
        expiry_date: this.data.passportInfo.expiry_date,
        openid: app.globalData.openid
      },
      method: 'POST',
      header: {
        'content-type': 'application/json; charset=UTF-8'
      },
      success: function (res) {
        console.log(res);

        if (!this.data.passportInfo.id) {
          this.data.passportInfo.id = res.data.id;
        }
      },
      error: function (res) {
        console.log(res.err)
      }
    })

    wx.navigateTo({
      url: '../photo/photo',
    })
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