const Util = {};

(function(){

// var base64map = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

// Crypto utilities
Util.dateFromString = function(str) {
	str = str.replace(/\D/g, '')
	if (str.length < 6) {
		return str
	}
	let dd = str.substr(0, 2)
	str = str.substr(2)
	let yyyy = str.substr(str.length - 4)
	if (str.length === 6) {
		return yyyy + '-' + 1 + '-' + dd
	} else {
		let mm = str.substr(0, str.length - 4)
		return yyyy + '-' + mm + '-' + dd
	}
};

Util.splitCnEnName = function(data, prop) {
	if (data[prop]) {
	  var places = data[prop].split('/', 2)
	  if (places.length === 2) {
		data[prop + '_cn'] = places[0]
		data[prop] = places[1]
	  }
	}
  };

})();

module.exports = Util;