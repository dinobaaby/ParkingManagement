import Glass from "./Glass";
import "./Glass.css";
export default function GlassMenu() {
    return (
        <div className="glasses">
            <Glass
                icon={"assets/icons/glass/ic_glass_users.png"}
                title={"User"}
                description="Manage your users"
            />
            <Glass
                icon={"assets/icons/glass/ic_glass_message.png"}
                title={"Role"}
                description="Manage your role"
            />
            <Glass
                icon={"assets/icons/glass/ic_glass_buy.png"}
                title={"Ticket"}
                description="Manage your ticket"
            />
            <Glass
                icon={"assets/icons/glass/ic_glass_bag.png"}
                title={"Bill"}
                description="Manage your users"
            />
        </div>
    );
}
