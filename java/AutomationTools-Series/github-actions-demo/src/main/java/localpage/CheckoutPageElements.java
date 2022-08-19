package localpage;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;

public class CheckoutPageElements {
    private final WebDriver driver;

    public CheckoutPageElements(WebDriver driver) {
        this.driver = driver;
    }

    public WebElement username() {
        return driver.findElement(By.id("username"));
    }


    public WebElement login() {
        return driver.findElement(By.id("tr-login"));
    }

    public WebElement password() {
        return driver.findElement(By.is("password")
    }
}
