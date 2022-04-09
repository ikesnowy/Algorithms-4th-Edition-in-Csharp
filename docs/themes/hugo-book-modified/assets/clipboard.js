(function () {
  function select(element) {
    const selection = window.getSelection();

    const range = document.createRange();
    range.selectNodeContents(element);

    selection.removeAllRanges();
    selection.addRange(range);
  }

  // #613 do nothing here
  // document.querySelectorAll("pre code").forEach(code => {
  //   code.addEventListener("click", function (event) {
  //     select(code.parentElement);

  //     if (navigator.clipboard) {
  //       navigator.clipboard.writeText(code.parentElement.textContent);
  //     }
  //   });
  // });
})();
