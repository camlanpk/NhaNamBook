function() {
    ai.trigger(t("resume", pi))
}
function(n) {
    n.preventDefault();
    ai.trigger(t("prev", pi))
}
function() {
    ai.trigger(t("pause", pi), i)
}
function(n) {
    n.preventDefault();
    ai.trigger(t("next", pi))
}
function onkeypress(event) {
    return KeyPressQty(event)
}
